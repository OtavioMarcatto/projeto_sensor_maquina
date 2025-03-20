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
}
