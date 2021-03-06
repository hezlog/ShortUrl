﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShortUrl.DataAccessLayer.Contacts
{
	public interface IRepository<T>
		where T : class
	{
		T Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		T Get(object id);
		IQueryable<T> Get();
	}
}