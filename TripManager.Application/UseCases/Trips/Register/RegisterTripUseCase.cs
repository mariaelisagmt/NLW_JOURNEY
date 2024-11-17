using TripManager.Communication.Requests;

namespace TripManager.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public void Execute(RequestRegisterTripJson request)
    {
        Validate(request);
    }

    private void Validate(RequestRegisterTripJson request)
    {
        if (String.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Nome não pode ser vazio");
        
        //INFO UTC = Data de todos os paises, o datetime.now pega do pc/servidor
        if (request.StartDate < DateTime.UtcNow)
            throw new ArgumentException("A viagem não pode ser registrada em uma data anterior");

        if (request.EndDate < request.StartDate)
            throw new ArgumentException("A viagem deve terminar apos a data de inicio");
    }
}
