package org.example;
import com.opencsv.CSVReader;
import com.opencsv.exceptions.CsvValidationException;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.keycloak.admin.client.Keycloak;
import org.keycloak.admin.client.resource.RealmResource;
import org.keycloak.admin.client.resource.RolesResource;
import org.keycloak.representations.idm.RoleRepresentation;

import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException, CsvValidationException {

        RealmResource realm = getRealmResource();
        RolesResource rolesResource = realm.roles();


        List<RoleRepresentation> keycloakRoles = rolesResource.list();
        List<String> csvRoles = readCSV();

        List<RoleComparison> comparisons = compareRoles(keycloakRoles, csvRoles);


        generateExcel(comparisons, "comparison.xlsx");
    }

    private static RealmResource getRealmResource() {
        String url;
        String realm;
        String username;
        String password;
        String clientId;
        if (System.getProperty("url") != null) {
            url = System.getProperty("url");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'url'.");
        }
        if (System.getProperty("realm") != null) {
            realm = System.getProperty("realm");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'realm'.");
        }

        if (System.getProperty("username") != null) {
            username = System.getProperty("username");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'username'.");
        }

        if (System.getProperty("password") != null) {
            password = System.getProperty("password");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'password'.");
        }

        if (System.getProperty("clientId") != null) {
            clientId = System.getProperty("clientId");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'clientId'.");
        }
        Keycloak keycloak = Keycloak.getInstance(
                url,
                realm,
                username,
                password,
                clientId);

        return keycloak.realm(realm);
    }

    private static List<String> readCSV() throws IOException, CsvValidationException {
        String filePath;
        if (System.getProperty("filePath") != null) {
            filePath = System.getProperty("filePath");
        } else {
            throw new IllegalArgumentException("Brak ustawionej wartości dla właściwości 'filePath'.");
        }
        CSVReader reader = new CSVReader(new FileReader(filePath));

        String[] data;
        List<String> roleCSV = new ArrayList<>();
        String data2 = Arrays.toString(reader.readNext());
        int indexRole = splitString(data2).indexOf("role");
        while ((data = reader.readNext()) != null) {
            List<String> valueRole = splitString(Arrays.toString(data));
            roleCSV.add(valueRole.get(indexRole));
        }
        return roleCSV;
    }

    private static List<String> splitString(String input) {
        List<String> parts = new ArrayList<>();
        String[] splitArray = input.split(";");
        for (String part : splitArray) {
            parts.add(part.replace("[", "").replace("]", "").trim());
        }
        return parts;
    }

    private static List<RoleComparison> compareRoles(List<RoleRepresentation> keycloakRoles, List<String> csvRoles) {
        List<RoleComparison> comparisons = new ArrayList<>();

        for (RoleRepresentation keycloakRole : keycloakRoles) {
            String roleName = keycloakRole.getName();
            boolean inCSV = csvRoles.contains(roleName);
            boolean inKeycloak = true;
            comparisons.add(new RoleComparison(roleName, inKeycloak, inCSV));
        }

        for (String roleName : csvRoles) {
            boolean inKeycloak = keycloakRoles.stream().anyMatch(role -> role.getName().equals(roleName));
            boolean inCSV = true;

            if (!inKeycloak) {
                comparisons.add(new RoleComparison(roleName, false, inCSV));
            }
        }
        comparisons.sort(Comparator.comparing(RoleComparison::getRoleName));

        return comparisons;
    }

    private static void generateExcel(List<RoleComparison> comparisons, String filename) throws IOException {
        Path path = Path.of(("../out"));
        if (!Files.exists(path)) {
            Files.createDirectories(path);
        }
        try (Workbook workbook = new XSSFWorkbook()) {
            Sheet sheet = workbook.createSheet("Role Comparison");

            Row headerRow = sheet.createRow(0);
            headerRow.createCell(0).setCellValue("Role Name");
            headerRow.createCell(1).setCellValue("Keycloak");
            headerRow.createCell(2).setCellValue("CSV");

            int rowNum = 1;
            for (RoleComparison comparison : comparisons) {
                Row row = sheet.createRow(rowNum++);
                Cell roleCell = row.createCell(0);
                roleCell.setCellValue(comparison.getRoleName());
                Cell keycloakCell = row.createCell(1);
                keycloakCell.setCellValue(comparison.isInKeycloak());
                Cell csvCell = row.createCell(2);
                csvCell.setCellValue(comparison.isInCSV());

                if (comparison.isInKeycloak() && comparison.isInCSV()) {
                    roleCell.setCellStyle(getGreenCellStyle(workbook));
                } else if (comparison.isInKeycloak()) {
                    roleCell.setCellStyle(getBlueCellStyle(workbook));
                } else if (comparison.isInCSV()) {
                    roleCell.setCellStyle(getRedCellStyle(workbook));
                }
            }

            try (FileOutputStream fileOut = new FileOutputStream(path+"/"+filename)) {
                workbook.write(fileOut);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static CellStyle getGreenCellStyle(Workbook workbook) {
        CellStyle style = workbook.createCellStyle();
        style.setFillForegroundColor(IndexedColors.LIGHT_GREEN.getIndex());
        style.setFillPattern(FillPatternType.SOLID_FOREGROUND);
        return style;
    }

    private static CellStyle getBlueCellStyle(Workbook workbook) {
        CellStyle style = workbook.createCellStyle();
        style.setFillForegroundColor(IndexedColors.LIGHT_BLUE.getIndex());
        style.setFillPattern(FillPatternType.SOLID_FOREGROUND);
        return style;
    }

    private static CellStyle getRedCellStyle(Workbook workbook) {
        CellStyle style = workbook.createCellStyle();
        style.setFillForegroundColor(IndexedColors.RED.getIndex());
        style.setFillPattern(FillPatternType.SOLID_FOREGROUND);
        return style;
    }
}
