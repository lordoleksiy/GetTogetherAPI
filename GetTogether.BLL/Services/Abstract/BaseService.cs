using AutoMapper;
using GetTogether.DAL.Context;

namespace GetTogether.BLL.Services;

public abstract class BaseService
{
    private protected readonly DataContext _context;
    private protected readonly IMapper _mapper;

    public BaseService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}