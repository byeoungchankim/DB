<?php

$servername = "localhost"; //�����̸�
$username = "root";			//����� �̸�
$password = "";		//��й�ȣ
$dbname = "db_login";		//db�̸�

$loginUser = $_POST("loginUser");
$loginPass = $_POST("loginPass");

$conn = new mysqli($servername, $username, $password, $dbname); //����

$sql = 
	"SELECT * FROM tb_longin WHRER id = '"
	.$loginUser. "'";
$result = $conn->query($sql); 


if($result->num_row > 0) {  //����ó��
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
