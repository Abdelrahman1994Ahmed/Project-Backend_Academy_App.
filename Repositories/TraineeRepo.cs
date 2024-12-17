using Academy.Data;
using Academy.Models;
using Academy.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repos
{
    public class TraineeRepo : ITraineeRepo
    {
        private readonly AppDbContext _context;

        public TraineeRepo(AppDbContext context)
        {
            _context = context; 
        }
        public async Task CreateTrainee(TraineeViewModel traineeViewModel)
        {

            Trainee newTrainee = new Trainee()
            {
                Name = traineeViewModel.Name,
                ImageURL = traineeViewModel.ImgURL,
                Grade = traineeViewModel.Grade,
                Address = traineeViewModel.Address,
                DepId = traineeViewModel.DepId,
                CourseId = traineeViewModel.CourseId,
            };
            await _context.Trainees.AddAsync(newTrainee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditTrainee(TraineeViewModel traineeViewModel,int Id)
        {
            Trainee curTrainee = await GetTraineeId(Id);
            if (curTrainee == null)
            {
                return false;
            }

            curTrainee.Name = traineeViewModel.Name;
            curTrainee.ImageURL = traineeViewModel.ImgURL;
            curTrainee.Grade = traineeViewModel.Grade;
            curTrainee.Address = traineeViewModel.Address;
            curTrainee.DepId = traineeViewModel.DepId;
            curTrainee.CourseId = traineeViewModel.CourseId;

            _context.Trainees.Update(curTrainee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Trainee> GetTraineeId(int Id)
        {
            return await _context.Trainees.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Trainee>> GetAll()
        {
            return await _context.Trainees.Include(x => x.Department).Include(x => x.Course).ToListAsync();
        }

        public async Task DeletTrainee(Trainee trainee)
        {
            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();
        }

    }
}
