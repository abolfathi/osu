﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Game.Online.API.Requests;
using osu.Game.Users;
using osu.Framework.Bindables;
using osu.Game.Online.API.Requests.Responses;
using osu.Game.Online.API;
using System.Collections.Generic;
using osuTK;

namespace osu.Game.Overlays.Profile.Sections.Recent
{
    public class PaginatedRecentActivityContainer : PaginatedContainer<APIRecentActivity>
    {
        public PaginatedRecentActivityContainer(Bindable<User> user, string missing)
            : base(user, missing)
        {
            ItemsPerPage = 10;
            ItemsContainer.Spacing = new Vector2(0, 8);
        }

        protected override APIRequest<List<APIRecentActivity>> CreateRequest() =>
            new GetUserRecentActivitiesRequest(User.Value.Id, VisiblePages++, ItemsPerPage);

        protected override Drawable CreateDrawableItem(APIRecentActivity model) => new DrawableRecentActivity(model);
    }
}
