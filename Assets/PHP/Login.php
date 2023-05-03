<?php

$servername = "localhost"; //서버이름
$username = "root";			//사용자 이름
$password = "";		//비밀번호
$dbname = "db_login";		//db이름

$loginUser = $_POST("loginUser");
$loginPass = $_POST("loginPass");

$conn = new mysqli($servername, $username, $password, $dbname); //선언

$sql = 
	"SELECT * FROM tb_longin WHRER id = '"
	.$loginUser. "'";
$result = $conn->query($sql); 


if($result->num_row > 0) {  //예외처리
	while($row = #result ->fetch_assoc())) {
	if($row["pw"] == $loginPass) {echo "Login success!!";
	$conn->close();
	exit;
	}
}
echo "Wrong password..";
}else{
echo "ID not found..";
}

$conn->close();
?>
