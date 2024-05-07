<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

$servername = "localhost";
$username = "root"; 
$password = "";
$database = "womack";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) 
{
    die("Connection failed: " . $conn->connect_error);
}

$query = "SELECT PlayerName, Score FROM scores ORDER BY Score DESC LIMIT 10"; 

$result = $conn->query($query); 

$high_scores = array();
if ($result->num_rows > 0) 
{
    while ($row = $result->fetch_assoc()) 
    {
        $high_scores[] = array(
            "PlayerName" => $row["PlayerName"], 
            "Score" => $row["Score"]
        );
    }
} 
else 
{
    echo json_encode($high_scores); 
}

echo json_encode($high_scores); 

$conn->close();

