using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Pages.WeatherPages
{
 public static class WeatherStore
 {
 private static readonly List<WeatherItem> _items = new();
 private static int _nextId =1;

 static WeatherStore()
 {
 var startDate = DateOnly.FromDateTime(DateTime.Now);
 var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
 for (int i =1; i <=5; i++)
 {
 _items.Add(new WeatherItem
 {
 Id = _nextId++,
 Date = startDate.AddDays(i),
 TemperatureC = Random.Shared.Next(-20,55),
 Summary = summaries[Random.Shared.Next(summaries.Length)]
 });
 }
 }

 public static IEnumerable<WeatherItem> GetAll() => _items;

 public static WeatherItem? GetById(int id) => _items.FirstOrDefault(i => i.Id == id);

 public static void Add(WeatherItem item)
 {
 item.Id = _nextId++;
 _items.Add(item);
 }

 public static void Update(WeatherItem item)
 {
 var existing = GetById(item.Id);
 if (existing is null) return;
 existing.Date = item.Date;
 existing.TemperatureC = item.TemperatureC;
 existing.Summary = item.Summary;
 }

 public static void Remove(int id)
 {
 var existing = GetById(id);
 if (existing is null) return;
 _items.Remove(existing);
 }

 public sealed class WeatherItem
 {
 public int Id { get; set; }
 public DateOnly Date { get; set; }
 public int TemperatureC { get; set; }
 public string? Summary { get; set; }
 public int TemperatureF =>32 + (int)(TemperatureC /0.5556);
 }
 }
}
