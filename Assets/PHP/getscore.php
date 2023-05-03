<?php

$servername = "localhost"; //서버이름
$username = "root";			//사용자 이름
$password = "asdf1234";		//비밀번호
$dbname = "db_score";		//db이름


$conn = new mysqli($servername, $username, $password, $dbname); //선언


if($conn->connect_error) {  //예외처리
	die ("connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM tb_score";
$result = $conn->query($sql);


if($result->num_rows>0)
{
	echo "[";
	while($row = $result->fetch_assoc()){
		echo "{'id': '".$row['id']."', 'score': '".$row['score']."'},";
	}
	echo "]";
}

/*
if($result->num_rows > 0) {
	$update_sql = "UPDATE tb_score SET score = '" . $score . "' WHERE id = '" . $id . "'";
	$conn->query($update_sql);
}
else {
	$insert_sql = "INSERT INTO tb_score (id, score)
				   VALUES ('" . $id . "', '" . $score . "')";
	$conn->query($insert_sql);
}
*/

$conn->close();

?>