import dll_types as math_lib


print("My bmi:", math_lib.calc_bmi(70.0, 1.85))
print("kCal:", math_lib.kCal_burned(72, math_lib.met_for_activity(3, 1), 60))
print()
out: list[float] = []
bmis: list[float] = math_lib.bmi_batch([70, 70.5, 71, 71.5, 72], [1.85, 1.85, 1.85, 1.85, 1.85])
print("My bmis:", bmis)
print()
activity: math_lib.Activity = math_lib.activity(10)
print(math_lib.activity_str(activity))
