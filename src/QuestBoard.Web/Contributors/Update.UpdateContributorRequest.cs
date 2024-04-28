﻿using System.ComponentModel.DataAnnotations;

namespace QuestBoard.Web.Contributors;

public class UpdateContributorRequest
{
  public const string Route = "/Contributors/{ContributorId:string}";
  public static string BuildRoute(Guid contributorId) => Route.Replace("{ContributorId:string}", contributorId.ToString());

  public Guid ContributorId { get; set; }

  [Required]
  public Guid Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
