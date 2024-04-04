# Aplikacja do porównywania ról w Keycloak i CSV

Ta aplikacja pozwala porównać role zdefiniowane w systemie Keycloak z rolami zawartymi w pliku CSV.
W wyniku jest generowany plik XLSX, który zawiera role które są:
- w CSV i w Keycloak, taki wiersz oznaczany jest na zielono
- tylko w CSV taki wiersz oznaczany jest na czerwono
- tylko w Keycloak taki wiersz oznaczany na niebiesko

Kolejność ról jest alfabetyczna.

## Technologie

- Java
- Docker
- Keycloak

## Uruchamianie aplikacji

Przed próbą uruchomienia aplikacji jeśli nie miałeś wcześniej keycloak, powinnieneś go pobrać keycloak otworzyć folder terminalu i uruchomić polecenie '.\bin\kc.bat start-dev', następnie na http://localhost:8080/ utwórz admin usera.

Zmienne realm, username, password i client_id odnoszą się do twoich parametrów keycloak.

### Za pomocą Dockera

1. Upewnij się, że masz zainstalowanego Dockera na swoim systemie oraz włączyłeś keycloak.
2. Przejdź do katalogu projektu.
3. Otwórz w terminalu folder i uruchom polecenie `docker build --build-arg path_to_csv={path_to_csv} -t {image-name} .` w terminalu, aby zbudować aplikację w kontenerze Docker.
4. Uruchom polecenie 'docker run -d -v "{desired-outside-docker-output}:/out" {image-name} {realm} {username} {password} {client_id}

Plik XLSX pojawi się w {desired-outside-docker-output}.
Jeśli chcesz żeby kontener odrazu się usuwał po wygenerowaniu pliku dodaj flagę --rm po docker run.
Jesli nie podasz path_to_csv aplikacja użyje przykładowego pliku role.csv z folderu.

### Lokalnie

1. Upewnij się, że masz zainstalowanego Javę na swoim systemie oraz włączyłeś keycloak.
2. Przejdź do folderu target w katalogu projektu i otwórz go w terminalu.
3. Uruchom aplikację za pomocą polecenia "java -Durl=http://localhost:8080/ -Drealm={realm} -Dusername={username} -Dpassword={password} -DclientId={client-Id} -DfilePath='{path-to-csv}' -jar application.jar".

Plik XLSX pojawi się w folderze /task/out

## Konfiguracja

Aby użyć aplikacji, musisz dostarczyć plik CSV z rolami do porównania oraz poświadczenia do serwera Keycloak.

### Plik CSV

Naglówki oraz wartości w pliku csv powinny być odzielone średnikem(;).