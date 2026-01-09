using System;
/*2. Web Browser Tab Navigation (Back/Forward Tabs)
Use Case: Users can navigate back and forward between opened tabs.
OOP Concepts:
 Interface: NavigationManager
 Encapsulation: Two stacks handle navigation state.
 Polymorphism: Could extend for mobile vs desktop browser*/
using System.Collections.Generic;
interface NavigationManager
{
    void OpenTab(string url);
    void Back();
    void Forward();
    string CurrentTab();
}
class TabNavigation : NavigationManager
{
    private Stack<string> backStack;
    private Stack<string> forwardStack;
    private string currentTab;

    public TabNavigation()
    {
        backStack = new Stack<string>();
        forwardStack = new Stack<string>();
        currentTab = null;
    }

    public void OpenTab(string url)
    {
        if (currentTab != null)
        {
            backStack.Push(currentTab);
            forwardStack.Clear();
        }
        currentTab = url;
        Console.WriteLine($"Opened tab: {currentTab}");
    }

    public void Back()
    {
        if (backStack.Count > 0)
        {
            forwardStack.Push(currentTab);
            currentTab = backStack.Pop();
            Console.WriteLine($"Navigated back to: {currentTab}");
        }
        else
        {
            Console.WriteLine("No tabs to go back to.");
        }
    }

    public void Forward()
    {
        if (forwardStack.Count > 0)
        {
            backStack.Push(currentTab);
            currentTab = forwardStack.Pop();
            Console.WriteLine($"Navigated forward to: {currentTab}");
        }
        else
        {
            Console.WriteLine("No tabs to go forward to.");
        }
    }

    public string CurrentTab()
    {
        return currentTab;
    }
}
class TabNavigationMain
{
    public void Call()
    {
        TabNavigation tabNav = new TabNavigation();
        tabNav.OpenTab("google.com");
        tabNav.OpenTab("stackoverflow.com");
        tabNav.OpenTab("github.com");
        tabNav.Back();
        tabNav.Back();
        tabNav.Forward();
        tabNav.OpenTab("reddit.com");
        tabNav.Back();
    }
}
