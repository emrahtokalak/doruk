﻿using Etch.OrchardCore.ContentPermissions.Models;
using Microsoft.AspNetCore.Http;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.ContentPermissions.Services
{
    public class ContentPermissionsService : IContentPermissionsService
    {
        #region Dependencies

        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Constructor

        public ContentPermissionsService(IContentDefinitionManager contentDefinitionManager, IHttpContextAccessor httpContextAccessor)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Helpers

        public bool CanAccess(ContentItem contentItem)
        {
            return CanAccess(contentItem.As<ContentPermissionsPart>());
        }

        public bool CanAccess(ContentPermissionsPart part)
        {
            if (part == null || !part.Enabled || part.Roles.Length == 0)
            {
                return true;
            }

            if (part.Roles.Contains("Anonymous"))
            {
                return true;
            }

            if (_httpContextAccessor.HttpContext.User == null)
            {
                return false;
            }

            if (part.Roles.Contains("Authenticated") && _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                return true;
            }

            foreach (var role in part.Roles)
            {
                if (_httpContextAccessor.HttpContext.User.IsInRole(role))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<ContentPermissionsPartSettings> GetSettingsAsync(ContentPermissionsPart part)
        {
            var contentTypeDefinition = await _contentDefinitionManager.GetTypeDefinitionAsync(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(x => string.Equals(x.PartDefinition.Name, nameof(ContentPermissionsPart), StringComparison.Ordinal));
            return contentTypePartDefinition.GetSettings<ContentPermissionsPartSettings>();
        }

        #endregion

    }

    public interface IContentPermissionsService
    {
        bool CanAccess(ContentItem contentItem);
        bool CanAccess(ContentPermissionsPart part);

        Task<ContentPermissionsPartSettings> GetSettingsAsync(ContentPermissionsPart part);
    }
}
