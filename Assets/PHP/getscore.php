<?php

$servername = "localhost"; //�����̸�
$username = "root";			//����� �̸�
$password = "asdf1234";		//��й�ȣ
$dbname = "db_score";		//db�̸�


$conn = new mysqli($servername, $username, $password, $dbname); //����


if($conn->connect_error) {  //����ó��
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