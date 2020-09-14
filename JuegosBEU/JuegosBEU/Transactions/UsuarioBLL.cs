using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegosBEU.Transactions
{
	public class UsuarioBLL
	{
		public static Usuario Get(int? id)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Usuario.Find(id);
		}

		public static void Create(Usuario p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Add(p);
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

		public static void Update(Usuario p)
		{
			using (DeliveryJWEntities db = new DeliveryJWEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Attach(p);
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
						Usuario p = db.Usuario.Find(id);
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

		public static List<Usuario> List()
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Usuario.ToList();
		}

		public static List<Usuario> List(string criterio)
		{
			DeliveryJWEntities db = new DeliveryJWEntities();
			return db.Usuario.Where(x => x.cedula.Contains(criterio)).ToList();
		}
	}
}
