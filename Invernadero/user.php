<?php

function register_user($register_data)
{
	$register_data['password']=md5($register_data['password']);
	
	$fields = '`'.implode('`,`', array_keys($register_data)).'`';
	$data = '\''.implode('\',\'', $register_data).'\'';
	mysql_query("INSERT INTO `users` ($fields) VALUES ($data)");
}

function user_exists($username)
{
	
	$query = mysql_query("SELECT COUNT(`user_id`) FROM `users` WHERE `username`='$username'");

	if(mysql_result($query, 0)==1)
		return true;
	else
		return false;
}

function email_exists($email)
{
	
	$query = mysql_query("SELECT COUNT(`user_id`) FROM `users` WHERE `Correo`='$email'");

	if(mysql_result($query, 0)==1)
		return true;
	else
		return false;
}

function user_is($username)
{
	return mysql_result(mysql_query("SELECT `user_id` FROM `users` WHERE `username`='$username'"), 0,'user_id');
}

function login($username,$password)
{
	$user_id=user_is($username);
	$password=md5($password);
	$query=mysql_query("SELECT COUNT(`user_id`) FROM `users` WHERE `username`='$username' AND `password`='$password'");
	if(mysql_result($query, 0)==1)
		return $user_id;
	else
		return false;
}
function user_data($user_id)
{
	$data= array();
	$user_id=(int)$user_id;
	$num=func_num_args();
	$argumentos=func_get_args();
	
	if($num>1)
	{
		unset($argumentos[0]);
		$fields='`'.implode('`,`', $argumentos).'`';
		$data=mysql_fetch_assoc(mysql_query("SELECT $fields FROM `users` WHERE `user_id`=$user_id"));
		
		return $data;
	}
}
?>