Select * from Products

Select * from Products
Where ProductName = 'QUeso Cabrales'

Select ProductName, UnitsInStock, SupplierID
from products 
where productname in ('Laugning Lumberjack Lager', 'Outback Lager', 'Ravioli Angelo')

select * 
from Orders
where CustomerID = 'QUEDE'

select *
from Orders
where Freight > 100

select *
from Orders
Where Freight <= 20 AND Freight >= 10 AND ShipCountry = 'USA'

--Get a list of each employee and their territories
select e.EmployeeID, LastName, FirstName, t.TerritoryDescription
from employees e
join EmployeeTerritories et on e.EmployeeID = et.EmployeeID
join Territories t on et.TerritoryID = t.TerritoryID

--Get the customer name, order date, and each order detail's product name for USA customers only
select companyname, orderdate, p.ProductName
from customers c
join orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.ProductID = p.ProductID
where c.Country = 'USA'

--Get all the order information where CHai was sold
select *
from Orders o
join [Order Details] od on o.OrderID = od.OrderID
join products p on od.ProductID = p.ProductID
where p.ProductName = 'Chai'