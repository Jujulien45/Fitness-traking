#ifndef __MAIN_H__
#define __MAIN_H__

#include <windows.h>

/*  To use this exported function of dll, include this header
 *  in your project.
 */

#ifdef BUILD_DLL
    #define DLL_EXPORT __declspec(dllexport)
#else
    #define DLL_EXPORT __declspec(dllimport)
#endif


#ifdef __cplusplus
extern "C"
{
#endif


typedef struct activity
{
    int activity_id;
    float met;
    const char* name;
} Activity;


/* constants exports */
int DLL_EXPORT under_weight();
int DLL_EXPORT normal_weight();
int DLL_EXPORT over_weight();
int DLL_EXPORT obese_weight();


float DLL_EXPORT calc_bmi(const float weight_kg, const float height_m);

int DLL_EXPORT bmi_category(const float bmi);

float DLL_EXPORT kCal_burned(const float weight_kg, const float met_per_hour, const float duration_min);

Activity DLL_EXPORT activity(int type_id);

float DLL_EXPORT met_for_activity(int type_id, float intensity);

const char* DLL_EXPORT name_for_activity(int type_id);

void DLL_EXPORT met_for_activity_batch(int* type_ids, int* intensities, float* out, int n);

void DLL_EXPORT bmi_batch(float* weights_kg, float* heights_m, float* out, int n);

void DLL_EXPORT calories_batch(float* weights_kg, float* mets_per_hour, float* durations_min, float* out, int n);

void DLL_EXPORT calories_intensities_batch(float* weights_kg, float* default_mets_per_hour, float* durations_min, float* intensities, float* out, int n);



#ifdef __cplusplus
}
#endif

#endif // __MAIN_H__
