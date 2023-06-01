using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsDealerApi.Dtos.TestDrive;

namespace CarsDealerApi.Services.TestDriveService
{
    public class TestDriveService : ITestDriveService
    {
        public Task<ServiceResponse<List<GetTestDriveDto>>> AddTestDrive(AddTestDriveDto newTestDrive)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetTestDriveDto>>> GetAllTestDrive()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetTestDriveDto>> GetTestDriveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}