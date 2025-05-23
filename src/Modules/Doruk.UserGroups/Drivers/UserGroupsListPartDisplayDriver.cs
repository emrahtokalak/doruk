﻿using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;
using Doruk.UserGroups.Models;
using Doruk.UserGroups.Services;
using Doruk.UserGroups.ViewModels;

namespace Doruk.UserGroups.Drivers;

public class UserGroupsListPartDisplayDriver(UserGroupsManager userGroupsManager) : ContentPartDisplayDriver<UserGroupsListPart>
{
    public async override Task<IDisplayResult> DisplayAsync(UserGroupsListPart part, BuildPartDisplayContext context)
    {
        var userGroups = await userGroupsManager.GetUserGroupNamesAsync();


        return Initialize<UserGroupsListPartViewModel>(GetDisplayShapeType(context), model =>
            model.UserGroups = part.UserGroups ?? [])
            .Location("Detail", "Content:10");
    }

    public async override Task<IDisplayResult> EditAsync(UserGroupsListPart part, BuildPartEditorContext context)
    {
        var userGroups = await userGroupsManager.GetUserGroupNamesAsync();

        return Initialize<UserGroupsListPartEditViewModel>("UserGroupsListPart_Edit", model =>
        {
            model.UserGroups = userGroups;
            model.SelectedUserGroups = part.UserGroups ?? [];
        });
    }

    public async override Task<IDisplayResult> UpdateAsync(UserGroupsListPart part, UpdatePartEditorContext context)
    {
        var model = new UserGroupsListPartEditViewModel();

        await context.Updater.TryUpdateModelAsync(model, Prefix);

        part.UserGroups = model.SelectedUserGroups;

        return Edit(part, context);
    }
}
