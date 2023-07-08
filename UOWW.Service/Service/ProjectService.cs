using AutoMapper;
using UOWW.Core.Interfaces;
using UOWW.Service.DTO.PMS;
using UOWW.Core.Entities;

namespace UOWW.Service.Service
{
    public class ProjectService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await _unitOfWork.Projects.GetAll();
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<bool> InsertAsync(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            return await _unitOfWork.Projects.Add(project);
        }

        public async Task<int> CompleteAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }
    }
}
