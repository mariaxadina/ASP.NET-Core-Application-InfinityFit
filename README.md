# ASP.NET-Core-Application-InfinityFit

## Introduction
InfinityFit is a responsive photo-sharing platform built with ASP.NET Razor Pages. We worked in an Agile Scrum team, collaborating closely to deliver features iteratively. InfinityFit is a gamified fitness and tourism app designed to make staying active fun and rewarding. Users can set personal goals, explore landmarks, and track their progress while exercising. The app incorporates gamification, rewarding users with badges, points, levels, and vouchers as they complete challenges, visit landmarks, and share their achievements, making fitness and exploration fun and engaging.

<p align="center">
    <img src="https://github.com/mariaxadina/ASP.NET-Core-Application-InfinityFit/blob/main/images/imagine1.png" width="70%" />
</p>

## Project Features
- User Roles: Visitor, Registered User, Moderator/Administrator

- Responsive Photo Sharing: Upload and share photos with the community from any device.

- Gamification: Earn badges, points, levels, and vouchers by completing challenges, visiting landmarks, and engaging with content.

- Landmark Tracking: Explore locations with integrated location services and track progress.

- Leaderboard: Track top performers and compete with other users to encourage friendly competition.
  
- Comments & Moderation: Safe community environment with comment moderation via integrated API.

- Interactive Feed: See updates and achievements from yourself and other users.

- Rewards System: Redeem earned badges and points for vouchers and perks.

  <p align="center">
    <img src="https://github.com/mariaxadina/ASP.NET-Core-Application-InfinityFit/blob/main/images/imagine2.png" width="70%" />
    <img src="https://github.com/mariaxadina/ASP.NET-Core-Application-InfinityFit/blob/main/images/imagine3.png" width="70%" />
</p>
## Technologies Used


### ASP.NET Core Razor Pages
InfinityFit is built using ASP.NET Core Razor Pages, a lightweight and page-focused web framework that simplifies building dynamic, data-driven websites. Razor Pages allows for clean separation of concerns by combining the HTML markup with server-side C# logic in .cshtml and .cshtml.cs files. This structure makes the application easier to manage and scale, especially for CRUD operations like adding photos, editing profiles, or moderating content. Razor Pages also integrates seamlessly with ASP.NET Core features like authentication, dependency injection, and model binding.

### SQL Server Database
InfinityFit uses a local SQL Server database to store all essential data, including user accounts, photos, badges, posts, vouchers, likes and comments. The database manages entity relationships such as users to photos, users to badges, and photos to comments. Entity Framework Core is used for smooth data access and manipulation, allowing features like leaderboard tracking, reward redemption, and progress monitoring to work seamlessly.

### External APIs
InfinityFit integrates with two external APIs:

Geoapify API (Location Services) – allows users to explore landmarks and track their visits.

OpenAPI (gpt-4o-mini) – ensures a safe and positive community by automatically flagging inappropriate content.

### Entity Framework Core 
Entity Framework Core was used as the Object-Relational Mapper (ORM) to interact with the database in a more intuitive and efficient way. It allowed us to work with data using .NET objects, eliminating the need for most SQL queries. Through EF Core, we handled data models, relationships, and migrations seamlessly, ensuring strong integration between the backend logic and the underlying database structure.

### Frontend and Styling
The app uses responsive design principles to ensure the interface works well on desktops, tablets, and mobile devices. CSS, animations, and gamification elements such as badges, points, and interactive feeds enhance user engagement and create a playful, motivating experience.

## Results
The final outcome of the project successfully met all the initial objectives. InfinityFit provides a complete gamified photo-sharing experience, allowing users to interact by liking posts, posting AI-moderated comments, and exploring daily locations, while offering custom features built with Razor Pages, Entity Framework, and ASP.NET Core.

### Collaboration
This project was developed in collaboration with [Bichel Stefan-Adrian](https://github.com/StefanAdrian2003) and [Chera Gabriel-Alexandru](https://github.com/gabirelul).
