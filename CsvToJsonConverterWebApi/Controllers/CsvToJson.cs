using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CsvToJsonConverterWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvToJson : ControllerBase
    {
        [HttpPost]
        public IActionResult Convert(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture);
                var records = csvReader.GetRecords<dynamic>();
                var json = JsonConvert.SerializeObject(records);
                return Ok(json);
            }
        }
       
        }
    }

