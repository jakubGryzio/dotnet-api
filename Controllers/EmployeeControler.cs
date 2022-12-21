using System;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using dotnet_api.Services;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeControler : ControllerBase
{
	public EmployeeControler()
	{
	}

    // GET all action
    [HttpGet]
    public ActionResult<List<Employee>> GetAll() =>
        EmployeeService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = EmployeeService.Get(id);
        if (employee == null)
        {
            return NotFound();
        }
        return employee;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        try
        {
            EmployeeService.Add(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.Id }, employee);
        } catch
        {
            return BadRequest();
        }
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        if (id != employee.Id) return BadRequest();

        var existingEmployee = EmployeeService.Get(id);
        if (existingEmployee is null) return NotFound();

        EmployeeService.Update(employee);
        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exisitngEmployee = EmployeeService.Get(id);
        if (exisitngEmployee is null) return NotFound();

        EmployeeService.Delete(id);
        return NoContent();
    }
}
