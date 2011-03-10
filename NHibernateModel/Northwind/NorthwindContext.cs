using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace OrmBattle.NHibernateModel.Northwind
{
  public class NorthwindContext 
  {
    public ISession Session { get; private set; }

    public NorthwindContext(ISession session)
    {
      Session = session;
    }

    public IQueryable<Category> Categories
    {
      get { return Session.Query<Category>(); }
    }

    public IQueryable<Customer> Customers
    {
      get { return Session.Query<Customer>(); }
    }

    public IQueryable<Employee> Employees
    {
      get { return Session.Query<Employee>(); }
    }

    public IQueryable<Order> Orders
    {
      get { return Session.Query<Order>(); }
    }

    public IQueryable<OrderDetail> OrderDetails
    {
      get { return Session.Query<OrderDetail>(); }
    }

    public IQueryable<Product> Products
    {
      get { return Session.Query<Product>(); }
    }

    public IQueryable<ActiveProduct> ActiveProducts
    {
      get { return Session.Query<ActiveProduct>(); }
    }

    public IQueryable<DiscontinuedProduct> DiscontinuedProducts
    {
      get { return Session.Query<DiscontinuedProduct>(); }
    }

    public IQueryable<Region> Regions
    {
      get { return Session.Query<Region>(); }
    }

    public IQueryable<Shipper> Shippers
    {
      get { return Session.Query<Shipper>(); }
    }

    public IQueryable<Supplier> Suppliers
    {
      get { return Session.Query<Supplier>(); }
    }

    public IQueryable<Territory> Territories
    {
      get { return Session.Query<Territory>(); }
    }
  }
}