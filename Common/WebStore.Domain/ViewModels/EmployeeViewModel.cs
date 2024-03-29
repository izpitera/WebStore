﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Domain.ViewModels
{
    public class EmployeeViewModel : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; init; }

        [Display(Name ="Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 15 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат фамилии")]
        public string LastName { get; init; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 15 символов")]
        public string Name { get; init; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; init; }

        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage = "Сотрудник должен быть в возрасте от 18 до 80 лет")]   
        public  int Age { get; init; }

        [Display(Name = "Зарплата")]
        public int Salary { get; init; }

        [Display(Name = "Гражданство")]
        public string Citizenship { get; init; }

        [Display(Name = "Пол")]
        public string Sex { get; init; }


        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            yield return ValidationResult.Success;
            //yield return new ValidationResult("Error Message put here", new [] {nameof(Name)});
        }
    }
}
