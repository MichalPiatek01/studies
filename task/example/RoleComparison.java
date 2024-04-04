package org.example;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
class RoleComparison {
    private String roleName;
    private boolean inKeycloak;
    private boolean inCSV;

    public RoleComparison(String roleName, boolean inKeycloak, boolean inCSV) {
        this.roleName = roleName;
        this.inKeycloak = inKeycloak;
        this.inCSV = inCSV;
    }

    @Override
    public String toString() {
        return "RoleName: " + roleName + ", In Keycloak: " + inKeycloak + ", In CSV: " + inCSV;
    }
}
