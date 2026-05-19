import ctypes

math_lib: ctypes.CDLL = ctypes.CDLL("Math C lib/Fitness-traking/bin/Debug/Fitness-traking.dll")


"""
ctypes cheat sheet
c_int           int      int
c_double        double   float
c_char_p        char*    bytes
c_void_p        void*    int/None
c_bool          bool     bool
POINTER(c_int)  int*     ctypes pointer
"""

math_lib.under_weight.argtypes = []



""" dll lib header
int DLL_EXPORT under_weight();
int DLL_EXPORT normal_weight();
int DLL_EXPORT over_weight();
int DLL_EXPORT obese_weight();


float DLL_EXPORT calc_bmi(const float weight_kg, const float height_m);

int DLL_EXPORT bmi_category(const float bmi);

float DLL_EXPORT kCal_burned(const float weight_kg, const float met_per_hour, const float duration_min);

float DLL_EXPORT met_for_activity(int type_id, float intensity);

const char* DLL_EXPORT name_for_activity(int type_id);

void DLL_EXPORT met_for_activity_batch(int* type_ids, int* intensities, float* out, int n);

void DLL_EXPORT bmi_batch(float* weights_kg, float* heights_m, float* out, int n);

void DLL_EXPORT calories_batch(float* weights_kg, float* mets_per_hour, float* durations_min, float* out, int n);

void DLL_EXPORT calories_intensities_batch(float* weights_kg, float* default_mets_per_hour, float* durations_min, float* intensities, float* out, int n);
"""