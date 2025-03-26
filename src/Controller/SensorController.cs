using Microsoft.AspNetCore.Mvc;
using Projeto_Sensor_Corrente.src.Dto;
using ProjetoSensor.Models;
using ProjetoSensor.Services;

namespace ProjetoSensor.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorController(SensorService sensorService) : ControllerBase
{
    private readonly SensorService _sensorService = sensorService;

    [HttpPost("medir")]
    public async Task<IActionResult> Medir([FromBody] MedicaoCorrente medicao)
    {
        var resultado = await _sensorService.AddMedicaoAsync(medicao);

        return Ok(
            new
            {
                status = "sucesso",
                id = resultado.Id,
                valor_corrente = resultado.ValorCorrente,
                data_hora = resultado.DataHora,
            }
        );
    }

    [HttpGet("medicao-result")]
    public async Task<ActionResult<List<MedicaoResultDtoResponse>>> MedirResult()
    {
        var response = await _sensorService.ResultMedicaoService();

        return Ok(response);
    }
}
