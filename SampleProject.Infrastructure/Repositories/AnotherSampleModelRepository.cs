﻿using Microsoft.Extensions.Configuration;
using SampleProject.Domain.BaseInterfaces;
using SampleProject.Domain.Interfaces;
using SampleProject.Domain.Models;
using SampleProject.Infrastructure.Implementations;
using SampleProject.Infrastructure.Repositories.QueryTexts;

namespace SampleProject.Infrastructure.Repositories;

public class AnotherSampleModelRepository(
    BaseDBContext dbContext,
    IConfiguration configuration,
    ICurrentUser currentUser
    ) : BaseRepository<AnotherSampleModel>(dbContext, new(configuration.GetConnectionString("AnotherSampleProjectConnection")), currentUser), IAnotherSampleModelRepository
{
    public async Task<int> GetTotalCount(CancellationToken cancellationToken = default)
    {
        var result = await QueryGetAsync<int>(Queries.GetAnotherSampleModelTotalCount, cancellationToken: cancellationToken);
        return result;
    }
}