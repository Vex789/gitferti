<?php
$servername = "148.224.51.25";
$username = "proyecto2";
$password = "34QXm16";
$dbname = "proyecto2";
echo "not";
// Create connection
$conn = new mysql_connect($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
else
echo "trabajando";
// sql to create table
$sql = "CREATE TABLE users (
user_id INT(255) UNSIGNED AUTO_INCREMENT PRIMARY KEY, 
Nombres VARCHAR(32) NOT NULL,
Apellidos VARCHAR(32) NOT NULL,
Correo VARCHAR(64) NOT NULL,
username VARCHAR(32) NOT NULL,
password VARCHAR(32) NOT NULL,
Tipo VARCHAR(32) NOT NULL,
)";

if ($conn->query($sql) === TRUE) {
    echo "Table MyGuests created successfully";
} else {
    echo "Error creating table: " . $conn->error;
}

$conn->close();
?>