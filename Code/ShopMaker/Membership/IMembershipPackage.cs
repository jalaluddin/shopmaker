﻿using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public interface IMembershipPackage : IEntity
	{
		string Name { get;set; }

		double Price { get;set; }

		string PriceDisplayText { get;set; }

		int MaxShopAllowed { get;set; }

		int MaxProductAllowed { get;set; }

		int MaxCategoryAllowed { get;set; }

		string Description { get;set; }

	}
}

