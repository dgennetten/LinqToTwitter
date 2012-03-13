﻿/***********************************************************
 * Credits:
 * 
 * Created By: Joe Mayo, 8/26/08
 * *********************************************************/

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

using LinqToTwitter.Common;

namespace LinqToTwitter
{
    /// <summary>
    /// information for a twitter user
    /// </summary>
    public class User
    {
        /// <summary>
        /// creates a new user based on an XML user fragment
        /// </summary>
        /// <param name="user">XML user fragment</param>
        /// <returns>new User instance</returns>
        public static User CreateUser(XElement user)
        {
            if (user == null)
            {
                return null;
            }

            var status = user.Element("status");
            var userID = user.GetString("id", "0");

            var newUser = new User
            {
                Identifier = new UserIdentifier
                {
                    ID = userID,
                    UserID = userID,
                    ScreenName = user.GetString("screen_name")
                },
                Name = user.GetString("name"),
                Location = user.GetString("location"),
                Description = user.GetString("description"),
                ProfileImageUrl = user.GetString("profile_image_url"),
                URL = user.GetString("url"),
                Protected = user.GetBool("protected"),
                FollowersCount = user.GetInt("followers_count"),
                ProfileBackgroundColor = user.GetString("profile_background_color"),
                ProfileTextColor = user.GetString("profile_text_color"),
                ProfileLinkColor = user.GetString("profile_link_color"),
                ProfileSidebarFillColor = user.GetString("profile_sidebar_fill_color"),
                ProfileSidebarBorderColor = user.GetString("profile_sidebar_border_color"),
                FriendsCount = user.GetInt("friends_count"),
                CreatedAt = user.GetDate("created_at", DateTime.MinValue),
                FavoritesCount = user.GetInt("favourites_count"),
                UtcOffset = user.GetString("utc_offset"),
                TimeZone = user.GetString("time_zone"),
                ProfileBackgroundImageUrl = user.GetString("profile_background_image_url"),
                ProfileBackgroundImageUrlHttps = user.GetString("profile_background_image_url_https"),
                ProfileBackgroundTile = user.GetString("profile_background_tile"),
                StatusesCount = user.GetInt("statuses_count"),
                Notifications = user.GetBool("notifications"),
                GeoEnabled = user.GetBool("geo_enabled"),
                Verified = user.GetBool("verified"),
                ContributorsEnabled = user.GetBool("contributors_enabled"),
                Following = user.GetBool("following"),
                ShowAllInlineMedia = user.GetBool("show_all_inline_media"),
                ListedCount = user.GetInt("listed_count"),
                FollowRequestSent = user.GetBool("follow_request_sent"),
                Status = Status.CreateStatus(status),
                CursorMovement = Cursors.CreateCursors(GrandParentOrNull(user))
            };

            return newUser;
        }

        private static XElement GrandParentOrNull(XElement node)
        {
            if (node != null && node.Parent != null && node.Parent.Parent != null)
                return node.Parent.Parent;

            return null;
        }

        /// <summary>
        /// type of user request (i.e. Friends, Followers, or Show)
        /// </summary>
        public UserType Type { get; set; }

        /// <summary>
        /// Query user's Twitter ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Query User ID for disambiguating when ID is screen name
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Query screen name
        /// On Input - disambiguates when ID is User ID
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Identity properties of this specific user
        /// </summary>
        public UserIdentifier Identifier { get; set; }

        /// <summary>
        /// Page to return
        /// </summary>
        /// <remarks>
        /// This was made obsolete for one API, but not Search. Therefore, we can't mark it as obsolete yet.
        /// </remarks>
        //[Obsolete("This property has been deprecated and will be ignored by Twitter. Please use Cursor/CursorMovement properties instead.")]
        public int Page { get; set; }

        /// <summary>
        /// Number of users to return for each page
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Indicator for which page to get next
        /// </summary>
        /// <remarks>
        /// This is not a page number, but is an indicator to
        /// Twitter on which page you need back. Your choices
        /// are Previous and Next, which you can find in the
        /// CursorResponse property when your response comes back.
        /// </remarks>
        public string Cursor { get; set; }

        /// <summary>
        /// Used to identify suggested users category
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Query for User Search
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Contains Next and Previous cursors
        /// </summary>
        /// <remarks>
        /// This is read-only and returned with the response
        /// from Twitter. You use it by setting Cursor on the
        /// next request to indicate that you want to move to
        /// either the next or previous page.
        /// </remarks>
        [XmlIgnore]
        public Cursors CursorMovement { get; internal set; }

        /// <summary>
        /// name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// location of user
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// user's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// user's image
        /// </summary>
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// user's image for use on HTTPS secured pages
        /// </summary>
        public string ProfileImageUrlHttps { get; set; }

        /// <summary>
        /// user's image is a defaulted placeholder
        /// </summary>
        public bool DefaultProfileImage{ get; set; }

        /// <summary>
        /// user's URL
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// user's profile has not been configured (is just defaults)
        /// </summary>
        public bool DefaultProfile { get; set; }

        /// <summary>
        /// is user protected
        /// </summary>
        public bool Protected { get; set; }

        /// <summary>
        /// number of people following user
        /// </summary>
        public int FollowersCount { get; set; }

        /// <summary>
        /// color of profile background
        /// </summary>
        public string ProfileBackgroundColor { get; set; }

        /// <summary>
        /// color of profile text
        /// </summary>
        public string ProfileTextColor { get; set; }

        /// <summary>
        /// color of profile links
        /// </summary>
        public string ProfileLinkColor { get; set; }

        /// <summary>
        /// color of profile sidebar
        /// </summary>
        public string ProfileSidebarFillColor { get; set; }

        /// <summary>
        /// color of profile sidebar border
        /// </summary>
        public string ProfileSidebarBorderColor { get; set; }

        /// <summary>
        /// number of friends
        /// </summary>
        public int FriendsCount { get; set; }

        /// <summary>
        /// date and time when profile was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// number of favorites
        /// </summary>
        public int FavoritesCount { get; set; }

        /// <summary>
        /// UTC Offset
        /// </summary>
        public string UtcOffset { get; set; }

        /// <summary>
        /// Time Zone
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// URL of profile background image
        /// </summary>
        public string ProfileBackgroundImageUrl { get; set; }

        /// <summary>
        /// URL of profile background image for use on HTTPS secured pages
        /// </summary>
        public string ProfileBackgroundImageUrlHttps { get; set; }

        /// <summary>
        /// Title of profile background
        /// </summary>
        public string ProfileBackgroundTile { get; set; }

        /// <summary>
        /// Should we use the profile background image?
        /// </summary>
        public bool ProfileUseBackgroundImage { get; set; }

        /// <summary>
        /// number of status updates user has made
        /// </summary>
        public int StatusesCount { get; set; }

        /// <summary>
        /// type of device notifications
        /// </summary>
        public bool Notifications { get; set; }

        /// <summary>
        /// Supports Geo Tracking
        /// </summary>
        public bool GeoEnabled { get; set; }

        /// <summary>
        /// Is a verified account
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Is contributors enabled on account?
        /// </summary>
        public bool ContributorsEnabled { get; set; }

        /// <summary>
        /// Is this a translator?
        /// </summary>
        public bool IsTranslator { get; set; }

        /// <summary>
        /// is authenticated user following this user
        /// </summary>
        public bool Following { get; set; }

        /// <summary>
        /// current user status (valid only in user queries)
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// User categories for Twitter Suggested Users
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Return results for specified language
        ///  Note: Twitter only supports a limited number of languages,
        ///  which include en, fr, de, es, it when this feature was added.
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// Indicates if user has inline media enabled
        /// </summary>
        public bool ShowAllInlineMedia { get; set; }

        /// <summary>
        /// Number of lists user is a member of
        /// </summary>
        public int ListedCount { get; set; }

        /// <summary>
        /// If authenticated user has requested to follow this use
        /// </summary>
        public bool FollowRequestSent { get; set; }
    }
}