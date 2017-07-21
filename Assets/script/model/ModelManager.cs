using System;

public class ModelManager
{
	public static UserModel user;


	public static void Init(){
		user = new UserModel();
	}
	
	public static void Clear(){
		user = null;
	}
}