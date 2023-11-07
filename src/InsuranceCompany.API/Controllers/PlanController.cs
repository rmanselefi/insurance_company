
using InsuranceCompany.Application.Services;
using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;

    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }


    // POST: /plans
    [HttpPost]
    public ActionResult<Plan> CreatePlan(PlanType planType, decimal price)
    {
        var plan = _planService.CreatePlan(planType, price);
        return CreatedAtAction(nameof(GetPlan), new { id = plan.Id }, plan);
    }

    // GET /plans
    [HttpGet]
    public ActionResult<IEnumerable<Plan>> GetPlans()
    {
        return _planService.GetAllPlans().ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetPlan(Guid id)
    {
        var plan = _planService.GetPlanById(id);
        if (plan == null) return NotFound();
        return Ok(plan);
    }
}
