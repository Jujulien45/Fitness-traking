#include "main.h"


/* constants */
#define OBESE_THRESHOLD 30.0f
#define OVER_THRESHOLD 25.0f
#define NORMAL_THRESHOLD 18.5f
#define UNDER_THRESHOLD 0.0f


#define BMI_ERROR -1
#define ACTIVITY_ID_ERROR -1.0f
#define ACTIVITY_NAME_ERROR ""
static const Activity ACTIVITY_ERROR = {-1,   -1.0f,  ""};

#define ACTIVITY_COUNT 100
static const Activity ACTIVITIES[] =
{
    {1,   0.9f,  "sleeping"},
    {2,   1.0f,  "lying awake"},
    {3,   1.0f,  "sitting quietly"},
    {4,   1.2f,  "standing quietly"},
    {5,   1.5f,  "desk work / typing"},
    {6,   2.0f,  "driving a car"},
    {7,   2.5f,  "cooking / light kitchen"},
    {8,   2.0f,  "slow walking (2 km/h)"},
    {9,   2.8f,  "walking (3.5 km/h)"},
    {10,  3.5f,  "walking (5 km/h)"},
    {11,  4.3f,  "walking brisk (6.5 km/h)"},
    {12,  4.0f,  "hiking (flat trail)"},
    {13,  6.0f,  "hiking (hills, backpack)"},
    {14,  3.0f,  "carrying groceries"},
    {15,  2.5f,  "light stretching"},
    {16,  3.0f,  "yoga"},
    {17,  3.0f,  "tai chi"},
    {18,  3.0f,  "pilates"},
    {19,  3.0f,  "dancing (ballroom)"},
    {20,  6.0f,  "dancing (aerobic)"},
    {21,  4.0f,  "cycling leisure (16 km/h)"},
    {22,  6.0f,  "cycling moderate (19 km/h)"},
    {23, 10.0f,  "cycling fast (25 km/h)"},
    {24,  3.5f,  "stationary bike (light)"},
    {25,  8.5f,  "stationary bike (vigorous)"},
    {26,  7.0f,  "jogging (8 km/h)"},
    {27, 10.0f,  "running (10 km/h)"},
    {28, 13.0f,  "running (13 km/h)"},
    {29, 16.0f,  "running (16 km/h)"},
    {30, 15.0f,  "sprint intervals"},
    {31,  6.0f,  "swimming laps (freestyle, mod)"},
    {32, 10.0f,  "swimming laps (vigorous)"},
    {33,  4.0f,  "water aerobics"},
    {34,  7.0f,  "rowing machine (moderate)"},
    {35, 12.0f,  "rowing machine (vigorous)"},
    {36,  5.0f,  "elliptical (moderate)"},
    {37,  8.0f,  "elliptical (vigorous)"},
    {38,  8.0f,  "jump rope (slow)"},
    {39, 12.0f,  "jump rope (fast)"},
    {40,  3.0f,  "weight training (light)"},
    {41,  6.0f,  "weight training (vigorous)"},
    {42,  8.0f,  "circuit training"},
    {43,  8.0f,  "push-ups"},
    {44,  8.0f,  "pull-ups"},
    {45,  5.0f,  "sit-ups / crunches"},
    {46,  8.0f,  "burpees"},
    {47, 10.0f,  "box jumps"},
    {48,  9.0f,  "kettlebell swings"},
    {49, 10.0f,  "battle ropes"},
    {50,  7.5f,  "rock climbing (indoor)"},
    {51,  8.0f,  "rock climbing (outdoor)"},
    {52,  6.5f,  "basketball"},
    {53,  7.0f,  "football (soccer)"},
    {54,  7.0f,  "tennis (singles)"},
    {55,  5.0f,  "tennis (doubles)"},
    {56,  5.5f,  "badminton"},
    {57,  4.0f,  "table tennis"},
    {58,  3.5f,  "volleyball"},
    {59,  8.0f,  "beach volleyball"},
    {60,  4.3f,  "golf (walking, carrying bag)"},
    {61,  2.5f,  "golf (riding cart)"},
    {62,  5.0f,  "baseball / softball"},
    {63,  8.3f,  "rugby"},
    {64,  8.0f,  "ice hockey"},
    {65,  5.5f,  "ice skating (leisure)"},
    {66,  7.5f,  "inline skating"},
    {67,  5.0f,  "skateboarding"},
    {68,  5.3f,  "skiing (downhill, moderate)"},
    {69,  7.0f,  "skiing (cross-country, mod)"},
    {70,  5.3f,  "snowboarding"},
    {71, 10.0f,  "martial arts (sparring)"},
    {72,  4.0f,  "martial arts (kata / forms)"},
    {73,  9.0f,  "boxing (sparring)"},
    {74,  8.5f,  "boxing (heavy bag)"},
    {75,  6.0f,  "wrestling"},
    {76,  4.0f,  "gymnastics"},
    {77,  3.0f,  "surfing"},
    {78,  5.0f,  "kayaking"},
    {79,  4.0f,  "paddleboarding (leisure)"},
    {80,  4.0f,  "canoeing"},
    {81,  4.0f,  "stair climbing (slow)"},
    {82,  8.8f,  "stair climbing (fast)"},
    {83,  9.0f,  "stair-climbing machine"},
    {84,  4.0f,  "gardening (digging, weeding)"},
    {85,  4.5f,  "lawn mowing (push)"},
    {86,  5.0f,  "chopping wood"},
    {87,  6.0f,  "shoveling snow"},
    {88,  3.5f,  "mopping floors"},
    {89,  3.5f,  "vacuuming"},
    {90,  5.0f,  "carrying/moving furniture"},
    {91,  3.5f,  "childcare (active play)"},
    {92,  3.0f,  "frisbee (casual)"},
    {93,  8.0f,  "frisbee (ultimate)"},
    {94,  3.5f,  "trampoline jumping"},
    {95,  3.5f,  "archery (standing)"},
    {96,  3.0f,  "bowling"},
    {97,  2.5f,  "billiards / pool"},
    {98,  5.5f,  "horse riding (trot)"},
    {99,  8.0f,  "HIIT"},
    {100, 9.0f,  "cross-fit style workout"},
};


#define UNDER_WEIGHT 0
#define NORMAL_WEIGHT 1
#define OVER_WEIGHT 2
#define OBESE_WEIGHT 3


/* constants exports */
int DLL_EXPORT under_weight()
{return UNDER_WEIGHT;}
int DLL_EXPORT normal_weight()
{return NORMAL_WEIGHT;}
int DLL_EXPORT over_weight()
{return OVER_WEIGHT;}
int DLL_EXPORT obese_weight()
{return OBESE_WEIGHT;}


/* Exported function */
float DLL_EXPORT calc_bmi(const float weight_kg, const float height_m)
{
    const float bmi = (weight_kg) / (height_m * height_m);
    return bmi;
}


int DLL_EXPORT bmi_category(const float bmi)
{
    if (bmi <= 0.0f) return BMI_ERROR;

    if (bmi >= OBESE_THRESHOLD) return OBESE_WEIGHT;
    else if (bmi >= OVER_THRESHOLD) return OVER_WEIGHT;
    else if (bmi >= NORMAL_THRESHOLD) return NORMAL_WEIGHT;
    else return UNDER_WEIGHT;
}


float DLL_EXPORT kCal_burned(const float weight_kg, const float met_per_hour, const float duration_min)
{
    const float kCal = met_per_hour * weight_kg * (duration_min / 60.0f);
    return kCal;
}


void DLL_EXPORT activity(int type_id, Activity* out)
{
    if (type_id > ACTIVITY_COUNT || type_id <= 0) *out = ACTIVITY_ERROR;
    *out = ACTIVITIES[type_id - 1];
    return;
}


float DLL_EXPORT met_for_activity(int type_id, float intensity)
{
    if (type_id > ACTIVITY_COUNT || type_id <= 0) return ACTIVITY_ID_ERROR;
    return ACTIVITIES[type_id + 1].met * intensity;
}


const char* DLL_EXPORT name_for_activity(int type_id)
{
    if (type_id > ACTIVITY_COUNT || type_id <= 0) return ACTIVITY_NAME_ERROR;
    return ACTIVITIES[type_id + 1].name;
}


void DLL_EXPORT met_for_activity_batch(int* type_ids, int* intensities, float* out, int n)
{
    for (int i = 0; i < n; i++) {
        *out = met_for_activity(*type_ids, *intensities);
        out++;
        type_ids++;
        intensities++;
    }
    return;
}



void DLL_EXPORT bmi_batch(float* weights_kg, float* heights_m, float* out, int n)
{
    for (int i = 0; i < n; i++) {
        *out = calc_bmi(*weights_kg, *heights_m);
        out++;
        weights_kg++;
        heights_m++;
    }
    return;
}


void DLL_EXPORT calories_batch(float* weights_kg, float* mets_per_hour, float* durations_min, float* out, int n)
{
    for (int i = 0; i < n; i++) {
        *out = kCal_burned(*weights_kg, *mets_per_hour, *durations_min);
        out++;
        weights_kg++;
        mets_per_hour++;
        durations_min++;
    }
    return;
}


void DLL_EXPORT calories_intensities_batch(float* weights_kg, float* default_mets_per_hour, float* durations_min, float* intensities, float* out, int n)
{
    for (int i = 0; i < n; i++) {
        *out = kCal_burned(*weights_kg, (*default_mets_per_hour) * (*intensities), *durations_min);
        out++;
        weights_kg++;
        default_mets_per_hour++;
        durations_min++;
        intensities++;
    }
    return;
}



/* DLL entry point */
BOOL APIENTRY DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
    switch (fdwReason)
    {
        case DLL_PROCESS_ATTACH:
            break;
        case DLL_PROCESS_DETACH:
            break;
        case DLL_THREAD_ATTACH:
            break;
        case DLL_THREAD_DETACH:
            break;
    }
    return TRUE;
}
