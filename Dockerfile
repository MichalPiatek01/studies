FROM eclipse-temurin:21.0.2_13-jdk-jammy


VOLUME /out
WORKDIR /app

ARG path_to_csv=role.csv
COPY target/application.jar /app/application.jar
COPY target/lib/*.jar /app/lib/
COPY $path_to_csv /app/role.csv
COPY start_app.sh /app/start_app.sh

ENTRYPOINT ["/app/start_app.sh"]
CMD []