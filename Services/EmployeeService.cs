using dotnet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_api.Services;

public static class EmployeeService
{
	static List<Employee> Employess { get; }
	static int nextId = 3;
	static EmployeeService()
	{
		Employess = new List<Employee>
		{
			new Employee
			{
				Id = 1,
				LastName = "Nowak",
				FirstName = "Zbychu",
				Salary = 6000,
				IsDeveloper = true,
				StartWorkingDate = new DateTime(2019, 10, 10)
			},
			new Employee
			{
				Id = 2,
				LastName = "Kowalska",
				FirstName = "Jadzia",
				Salary = 3000,
				IsDeveloper = false,
				StartWorkingDate = new DateTime(2010, 01, 10)
			}
		};
	}

	public static List<Employee> GetAll() => Employess;

	public static Employee? Get(int id) => Employess.FirstOrDefault(e => e.Id == id);

	public static void Add(Employee employee)
	{
		employee.Id = nextId++;
		Employess.Add(employee);
	}

	public static void Delete(int id)
	{
		var employee = Get(id);
		if (employee is null) return;
		Employess.Remove(employee);
	}

	public static void Update(Employee employee)
	{
		var index = Employess.FindIndex(e => e.Id == employee.Id);
		if (index == -1) return;
		Employess[index] = employee;
	}
}