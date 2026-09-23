using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{

    public ActionResult<List<Item>> Get() => ItemsData.Items;

    [HttpGet("[action]/id")]
    public ActionResult<Item?> Get(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("invalid id");
        }
        var item = ItemsData.Items.Find(cur => cur.Id == Guid.Parse(id));
        return item != null ? Ok(item) : BadRequest();
    }

    [HttpPost("[action]")]
    public ActionResult Create(Item item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        ItemsData.Items.Add(item);
        return NoContent();
    }
    [HttpPut("[action]")]
    public ActionResult Update(string id, Item item)
    {

        if (!ModelState.IsValid || string.IsNullOrEmpty(id))
        {
            return BadRequest();
        }
        var selecetedItem = ItemsData.Items.Find(cur => cur.Id == Guid.Parse(id));
        if (selecetedItem is null)
        {
            return BadRequest();
        }
        selecetedItem = item;
        ItemsData.Items.Remove(selecetedItem);
        ItemsData.Items.Add(item);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public ActionResult Delete(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest();
        }
        var item = ItemsData.Items.Find(item => item.Id == Guid.Parse(id));
        if (item is null)
        {
            return BadRequest();
        }
        ItemsData.Items.Remove(item);
        return NoContent();
    }


}
