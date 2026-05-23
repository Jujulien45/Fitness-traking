import ctypes

math_lib: ctypes.CDLL = ctypes.CDLL("Math_C_lib/Math_C_lib/bin/Debug/Math C lib.dll")



# ctypes structures
class Activity(ctypes.Structure):
    """A clone of the Activity struct from the compiled C in the dll library.
    """
    _fields_ = [
        ("activity_id", ctypes.c_int),
        ("met", ctypes.c_float),
        ("name", ctypes.c_char_p)
    ]

def activity_str(activity: Activity):
    """generates a str for the Activity class to be printed.
    format: f"activity_id: ...; met: ...; name: ..."
    """
    return f"activity_id: {activity.activity_id}; met: {activity.met}; name: {activity.name}"


# Math C lib constants repliqua
BMI_ERROR: int = -1
ACTIVITY_ID_ERROR: float = -1.0
ACTIVITY_NAME_ERROR: str = ""
ACTIVITY_ERROR: Activity = Activity(-1, -1.0, b"")

# ctypes CDLL arg types
math_lib.under_weight.argtypes = []
math_lib.under_weight.restype = ctypes.c_int

math_lib.normal_weight.argtypes = []
math_lib.normal_weight.restype = ctypes.c_int

math_lib.over_weight.argtypes = []
math_lib.over_weight.restype = ctypes.c_int

math_lib.obese_weight.argtypes = []
math_lib.obese_weight.restype = ctypes.c_int



math_lib.calc_bmi.argtypes = [ctypes.c_float, ctypes.c_float]
math_lib.calc_bmi.restype =  ctypes.c_float

math_lib.bmi_category.argtypes = [ctypes.c_float]
math_lib.bmi_category.restype =  ctypes.c_int

math_lib.kCal_burned.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float]
math_lib.kCal_burned.restype =  ctypes.c_float

math_lib.met_for_activity.argtypes = [ctypes.c_int, ctypes.c_float]
math_lib.met_for_activity.restype =  ctypes.c_float

math_lib.name_for_activity.argtypes = [ctypes.c_int]
math_lib.name_for_activity.restype =  ctypes.c_char_p

math_lib.met_for_activity_batch.argtypes = [ctypes.POINTER(ctypes.c_int), ctypes.POINTER(ctypes.c_int), ctypes.POINTER(ctypes.c_float), ctypes.c_int]
math_lib.met_for_activity_batch.restype =  None

math_lib.bmi_batch.argtypes = [ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.c_int]
math_lib.bmi_batch.restype =  None

math_lib.calories_batch.argtypes = [ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.c_int]
math_lib.calories_batch.restype =  None

math_lib.calories_intensities_batch.argtypes = [ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.POINTER(ctypes.c_float), ctypes.c_int]
math_lib.calories_intensities_batch.restype =  None

math_lib.activity.argtypes = [ctypes.c_int, ctypes.POINTER(Activity)]
math_lib.activity.restype = None



# warpers to lint the types #
# under weight index returned by bmi_category()
under_weight: int = math_lib.under_weight()
# normal weight index returned by bmi_category()
normal_weight: int = math_lib.normal_weight()
# over weight index returned by bmi_category()
over_weight: int = math_lib.over_weight()
# obese weight index returned by bmi_category()
obese_weight: int = math_lib.obese_weight()


def calc_bmi(weight_kg: float | int, height_m: float | int) -> float | int:
    """Calculates the bmi of someone.
    
    :param weight_kg: the weight of the person in kilograms.
    :param height_m: the height of the person in meters.
    :returns: The bmi value in kg/m².
    """
    return math_lib.calc_bmi(weight_kg, height_m)

def bmi_category(bmi: float | int) -> int:
    """Calculates the bmi category of someone.
    
    :param bmi: The bmi of the person in kg/m².
    :returns: The bmi category, BMI_ERROR (-1) if an input is wrong,
    under_weight (0) if under,
    normal_weight (1) if normal,
    over_weight (2) if over,
    obese_weight (3) if obese.
    """
    bmi_category: int = math_lib.bmi_category(bmi)
    if bmi_category == BMI_ERROR:
        raise ValueError(f"bmi value({bmi}) has to be positive.")
    return bmi_category

def kCal_burned(weight_kg: float | int, met_per_hour: float | int, duration_min: int) -> float | int:
    """Estimates the kilo calories burned after doing an activity.

    :param weight_kg: The weight of the person doing the activity in kilograms.
    :param met_per_hour: The calories burned per hour doing this activity in MET/h.
    :param duration_min: The duration of the activity in minutes.
    :returns: The calories burned doing that activity in kCal.
    """
    return math_lib.kCal_burned(weight_kg, met_per_hour, duration_min)

def met_for_activity(type_id: int, intensity: float | int = 1) -> float | int:
    """Gets the MET/h value for an activity.

    :param type_id: The id of the activity.
    :param intensity: The intensity at which the activity was done, defaults to one.
    :returns: The met for the activity times the intensity, ACTIVITY_ID_ERROR (-1.0) if the type_id is out of range.
    """
    activity_met: float | int = math_lib.met_for_activity(type_id, intensity)
    if activity_met == ACTIVITY_ID_ERROR:
        raise ValueError(f"type_id({type_id} has to be between 0 and 100)")
    return activity_met

def name_for_activity(type_id: int) -> str:
    """Gets the name for an activity.

    :param type_id: The id of the activity.
    :returns: The name of the activity, ACTIVITY_NAME_ERROR ("") if the type_id is out of range.
    """
    activity_name: str = math_lib.name_for_activity(type_id)
    if activity_name == ACTIVITY_NAME_ERROR:
        raise ValueError(f"type_id({type_id} has to be between 0 and 100)")
    return activity_name

def activity(type_id: int) -> Activity:
    """Gets the activity struct instance for an activity.

    :param type_id: The id of the activity.
    :returns: The activity, ACTIVITY_ERROR (Activity(-1, -1.0, b"")) if the type_id is out of range.
    """
    out: Activity = Activity()
    math_lib.activity(type_id, ctypes.byref(out))
    if out == ACTIVITY_ERROR:
        raise ValueError(f"type_id({type_id} has to be between 0 and 100)")
    return out


def met_for_activity_batch(
        type_ids: list[int],
        intensities: list[float | int] = []) -> list[float]:
    """Gets the MET/h values for a batch of activities.

    :param type_ids: The ids of the activities.
    :param intensities: The intensities at which the activities were done, defaults to one.
    :returns: The mets for the activities times the intensities, ACTIVITY_ID_ERROR (-1.0) if the type_id is out of range.
    """
    n: int = min(len(type_ids), len(intensities))
    type_ids_arr = (ctypes.c_int * len(type_ids))(*type_ids)
    if intensities:
        intensities_arr = (ctypes.c_float * len(intensities))(*intensities)
    else:
        intensities_arr = (ctypes.c_float * n)(*[1 for i in range(n)])
    out_arr = (ctypes.c_float * n)()
    math_lib.met_for_activity_batch(type_ids_arr, intensities_arr, out_arr, n)
    return list(out_arr)

def calories_batch(
        weights_kg: list[float | int],
        mets_per_hour: list[float | int],
        durations_min: list[int]) -> list[float | int]:
    """Estimates kilo calories burned for a batch of activities.

    :param weights_kg: The weights of the persons doing the activities in list[kilograms].
    :param mets_per_hour: The calories burned per hour doing each activity in list[MET/h].
    :param durations_min: The durations of the activities in list[minutes].
    :returns: The calories burned doing each activity in list[kCal].
    """
    n: int = min(len(weights_kg), len(mets_per_hour))
    weights_kg_arr = (ctypes.c_float * len(weights_kg))(*weights_kg)
    mets_per_hour_arr = (ctypes.c_float * len(mets_per_hour))(*mets_per_hour)
    durations_min_arr = (ctypes.c_float * len(durations_min))(*durations_min)
    out_arr = (ctypes.c_float * n)()
    math_lib.calories_batch(weights_kg_arr, mets_per_hour_arr, durations_min_arr, out_arr, n)
    return list(out_arr)


def calories_intensities_batch(
        weights_kg: list[float | int],
        default_mets_per_hour: list[float | int],
        durations_min: list[int],
        intensities: list[float | int]) -> list[float | int]:
    """Estimates kilo calories burned for a batch of activities.

    :param weights_kg: The weights of the persons doing the activities in list[kilograms].
    :param default_mets_per_hour: The calories burned per hour doing each activity in list[MET/h].
    :param durations_min: The durations of the activities in list[minutes].
    :param intensities: The intensities of the batch of activities.
    :returns: The calories burned doing each activity in list[kCal].
    """
    n: int = min(len(weights_kg), len(default_mets_per_hour))
    weights_kg_arr = (ctypes.c_float * len(weights_kg))(*weights_kg)
    default_mets_per_hour_arr = (ctypes.c_float * len(default_mets_per_hour))(*default_mets_per_hour)
    durations_min_arr = (ctypes.c_float * len(durations_min))(*durations_min)
    intensities_arr = (ctypes.c_float * len(intensities))(*intensities)
    out_arr = (ctypes.c_float * n)()
    math_lib.calories_intensities_batch(weights_kg_arr, default_mets_per_hour_arr, durations_min_arr, intensities_arr, out_arr, n)
    return list(out_arr)


def bmi_batch(
        weights_kg: list[float | int],
        heights_m: list[float | int]) -> list[float | int]:
    """Calculates the bmi of a list of person.
    
    :param weights_kg: the weights of each person in list[kilograms].
    :param heights_m: the height of each person in list[meters].
    :returns: The bmis values, a list[kg/m²].
    """
    n: int = min(len(weights_kg), len(heights_m))
    weights_kg_arr = (ctypes.c_float * len(weights_kg))(*weights_kg)
    heights_m_arr = (ctypes.c_float * len(heights_m))(*heights_m)
    out_arr = (ctypes.c_float * n)()
    math_lib.bmi_batch(weights_kg_arr, heights_m_arr, out_arr, n)
    return list(out_arr)