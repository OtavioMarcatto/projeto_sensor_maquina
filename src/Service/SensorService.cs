using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Sensor_Corrente.src.Dto;
using ProjetoSensor.Data;
using ProjetoSensor.Models;

namespace ProjetoSensor.Services;

public class SensorService(ProjetoSensorContext context)
{
    private readonly ProjetoSensorContext _context = context;

    public async Task<MedicaoCorrente> AddMedicaoAsync(MedicaoCorrente medicao)
    {
        _context.Medicoes.Add(medicao);
        await _context.SaveChangesAsync();

        return medicao;
    }

    public async Task<List<MedicaoResultDtoResponse>> ResultMedicaoService()
    {
        var medicoes = await _context.Medicoes.ToListAsync();

        var medicoesDto = medicoes
            .Select(m => new MedicaoResultDtoResponse
            {
                Id = m.Id,
                ValorCorrente = m.ValorCorrente,
                DataHora = m.DataHora,
            })
            .ToList();

        return medicoesDto;
    }
}
