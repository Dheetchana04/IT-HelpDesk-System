using ITDesk.Data;
using ITDesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class TicketsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public TicketsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Admin Assign Ticket Page
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Assign(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
            return NotFound();

        // Get all ITSupport users
        var supportUsers = await _userManager.GetUsersInRoleAsync("ITSupport");

        ViewBag.SupportUsers = supportUsers;

        return View(ticket);
    }

    // Save Assignment
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Assign(int id, string supportId)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
            return NotFound();

        ticket.AssignedToId = supportId;
        ticket.Status = "In Progress";

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
