﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hn_console.Model;

namespace hn_console.Interface
{
    interface IConsoleService
    {
        void NavigateStories(List<Item> stories, int cursorPosition);

        void DisplayStories(List<Item> stories);

        void DisplayStoryComments(Item story, int level);

        void PrintClean(string content, string contentDetails, int tabs);

        void DisplayStoryHeader(Item story);

        string BuildStoryDetails(Item story);

        string BuildStoryContentDetails(Item item);

        void SetConsoleDetails();
    }
}
