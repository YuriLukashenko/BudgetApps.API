using System;
using System.Collections.Generic;
using System.Globalization;
using BudgetApps.API.DTOs.Flux;

namespace BudgetApps.API.ViewModels
{
    public class FluxViewModel
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public static FluxViewModel MapFrom(FluxViewDTO dto)
        {
            if (dto == null)
                return null;

            return new FluxViewModel()
            {
                Type = dto.Type,
                Value = Convert.ToDouble(dto.Value),
                Date = DateTime.ParseExact(dto.Date, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Comment = dto.Comment
            };
        }

        public static IEnumerable<FluxViewModel> MapFrom(IEnumerable<FluxViewDTO> dtos)
        {
            if (dtos == null)
                yield break;

            foreach (var dto in dtos)
            {
                yield return MapFrom(dto);
            }
        }
    }
}
