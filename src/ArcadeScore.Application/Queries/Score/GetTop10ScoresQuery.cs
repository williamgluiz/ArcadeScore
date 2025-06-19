using System.Collections.Generic;
using ArcadeScore.Application.DTOs;
using MediatR;

namespace ArcadeScore.Application.Queries.Score
{
    /// <summary>
    /// Query request to retrieve the top 10 highest scores recorded in the system.
    /// </summary>
    public class GetTop10ScoresQuery : IRequest<IEnumerable<ScoreResultDTO>>
    {
    }
}
