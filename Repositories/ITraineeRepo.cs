using Academy.Models;
using Academy.ViewModels;

namespace Academy.Repos
{
    public interface ITraineeRepo
    {
        Task CreateTrainee(TraineeViewModel traineeViewModel);
        Task<bool> EditTrainee(TraineeViewModel traineeViewModel, int Id);
        Task<Trainee> GetTraineeId(int Id);
        Task<IEnumerable<Trainee>> GetAll();
        Task DeletTrainee(Trainee trainee);
    }
}
