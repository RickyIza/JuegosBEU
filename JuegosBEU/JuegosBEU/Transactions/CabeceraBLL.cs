using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosBEU.Transactions
{
	public class CabeceraBLL
	{
		public static CabeceraPedido Get(int? id)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.CabeceraPedido.Find(id);
		}

		public static void Create(CabeceraPedido p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.CabeceraPedido.Add(p);
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}

		public static void Update(CabeceraPedido p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.CabeceraPedido.Attach(p);
						db.Entry(p).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static void Delete(int? id)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						CabeceraPedido p = db.CabeceraPedido.Find(id);
						db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static List<CabeceraPedido> List()
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.CabeceraPedido.ToList();
		}
	}
}
