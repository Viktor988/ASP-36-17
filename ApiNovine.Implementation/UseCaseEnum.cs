using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNovine.Implementation
{
	public enum UseCaseEnum
	{
		createCategory=3,
		deleteCategory = 5,
		updatecategory = 4,
		createcomment = 7,
		deletecomment = 8,
		deletepicture = 10,
		Createpost = 13,
		Updatepost = 14,
		deletepost = 15,
		insertrate = 33,
		createrole = 18,
		updaterole = 19,
		deleterole = 20,
		createtag = 23,
		updatetag = 24,
		deletetag = 25,
		createuser = 28,
		updateuser = 29,
		deleteuser = 30,
		registeruser=31,
		getcategory = 2,
		getcategories = 1,
		getcomment=6,
		getpicture=9,
		getpost=12,
		getposts=11,
		getroles=17,
		getrole=16,
		gettags=21,
		gettag=22,
		getusers=26,
		getuser=27,
		getuselog=32,
		updatecomment=34,
		getonecomment=35,
		getrates=36,
		deleterate=37,
		updaterate=38,
		getrate=39

	}
}
