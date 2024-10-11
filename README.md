## Problemas con la base de datos
Si tenemos problemas con la conexion a la base de datos, debemos verificar la cadena de conexion que se encuentra en el appsettings.json

![image](https://github.com/user-attachments/assets/9ef048d8-f37d-49eb-a0d9-315f2249e966)

en la linea 3 encuentraremos la cadena de conexion y deberiamos de cambiar el valor de "server" por el server name que nos muestra el sqlserver al momento de ingresar

![image](https://github.com/user-attachments/assets/18e7cfbd-1c68-4671-a9e9-55be9d0bfaba)

Cambiando por nuestro server name ya deberiamos poder consultar a la base de datos (Recuerde, en la carpeta Database se encuentra el .bak de la base con los datos, en caso de no usar el bak, la aplicacion creara una base de datos con las tablas pero esta no tendra datos)
