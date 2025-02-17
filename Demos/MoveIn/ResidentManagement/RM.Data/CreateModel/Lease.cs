﻿using Microsoft.EntityFrameworkCore;
using SLS.RM.Domain;

namespace SLS.RM.Data;

internal static partial class CreateModel
{

	internal static void Lease(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Lease>(entity =>
		{
			entity.ToTable("Lease", "LM");

			entity.Property(e => e.EndDate).HasColumnType("date");

			entity.Property(e => e.ExternalId).HasMaxLength(100);

			entity.Property(e => e.StartDate).HasColumnType("date");

			entity.HasOne(d => d.Resident)
					.WithMany(p => p.Leases)
					.HasForeignKey(d => d.ResidentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkLease_Resident");
		});
	}

}