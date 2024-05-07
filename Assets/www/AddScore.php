<?php
$servername = "localhost"; 
$username = "root"; 
$password = ""; 
$database = "womack"; 

// Connect to the database
$conn = new mysqli($servername, $username, $password, $database);

// Check connection
if ($conn->connect_error) 
{
    die("Connection failed: " . $conn->connect_error);
}

$player_name = $_POST['PlayerName'];
$score = (int)$_POST['Score']; 

$stmt = $conn->prepare("INSERT INTO scores (PlayerName, Score) VALUES (?, ?)");
$stmt->bind_param("si", $player_name, $score); 

if ($stmt->execute()) 
{
    echo "Score successfully added.";
} 
else 
{
    echo "Error: " . $stmt->error;
}

$stmt->close();
$conn->close();
