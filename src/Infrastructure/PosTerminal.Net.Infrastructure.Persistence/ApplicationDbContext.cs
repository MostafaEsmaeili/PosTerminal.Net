﻿using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Infrastructure.Persistence;

public class ApplicationDbContext: IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        base.SavingChanges += OnSavingChanges;
    }
    

    private void OnSavingChanges(object sender, SavingChangesEventArgs e)
    {
        CleanString();
        ConfigureEntityDates();
    }

    private void CleanString()
    {
        var changedEntities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
        foreach (var item in changedEntities)
        {
            if (item.Entity == null)
                continue;

            var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

            foreach (var property in properties)
            {
                var propName = property.Name;
                var val = (string)property.GetValue(item.Entity, null);

                if (val.HasValue())
                {
                    var newVal = val.Fa2En().FixPersianChars();
                    if (newVal == val)
                        continue;
                    property.SetValue(item.Entity, newVal, null);
                }
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.AddRestrictDeleteBehaviorConvention();
        modelBuilder.AddPluralizingTableNameConvention();
    }
    private void ConfigureEntityDates()
    {
        var updatedEntities = ChangeTracker.Entries().Where(x =>
            x.Entity is ITimeModification && x.State == EntityState.Modified).Select(x => x.Entity as ITimeModification);

        var addedEntities = ChangeTracker.Entries().Where(x =>
            x.Entity is ITimeModification && x.State == EntityState.Added).Select(x => x.Entity as ITimeModification);

        foreach (var entity in updatedEntities)
        {
            if (entity != null)
            {
                entity.LastModified = DateTime.Now;
            }
        }

        foreach (var entity in addedEntities)
        {
            if (entity != null)
            {
                entity.Created = DateTime.Now;
                entity.LastModified = DateTime.Now;
            }
        }
    }
}