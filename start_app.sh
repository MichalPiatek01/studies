#!/bin/bash

java -Durl=http://host.docker.internal:8080 -Drealm="$1" -Dusername="$2" -Dpassword="$3" -DclientId="$4" -DfilePath="role.csv" -jar application.jar